import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Patient } from '../_models/patient';
import { PatientService } from '../_services/patient.service';

@Component({
  selector: 'app-patient-view',
  templateUrl: './patient-view.component.html',
  styleUrls: ['./patient-view.component.css']
})
export class PatientViewComponent implements OnInit {
  patient!: Patient;

  constructor(private route: ActivatedRoute, private patientService: PatientService) { }

  ngOnInit(): void {
    let patientUiId = this.route.snapshot.paramMap.get('id');
    if (patientUiId !== null) {
      this.getPatient(+patientUiId);
    }
    
  }

  getPatient(patientId: number) {
    return this.patientService.getPatient(patientId).subscribe(
      (result: any) => {
        this.patient = result;
      },
      error => {
        alert('Error getting patient');
      }
    );
  }

}
