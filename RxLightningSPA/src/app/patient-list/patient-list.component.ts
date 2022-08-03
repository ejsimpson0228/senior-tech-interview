import { Component, OnInit } from '@angular/core';
import { Patient } from '../_models/patient';
import { PatientService } from '../_services/patient.service';

@Component({
  selector: 'app-patient-list',
  templateUrl: './patient-list.component.html',
  styleUrls: ['./patient-list.component.css']
})
export class PatientListComponent implements OnInit {
  patientList: Patient[] = [];

  constructor(private patientService: PatientService) { }

  ngOnInit(): void {
    this.getPatients();
  }

  getPatients() {
    this.patientService.getPatients().subscribe(
      (result: any) => {
        this.patientList = result;
      },
      error => {
        alert('Error retrieving patients');
      }
    );
  }

}
