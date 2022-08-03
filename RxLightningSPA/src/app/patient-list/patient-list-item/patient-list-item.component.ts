import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Patient } from 'src/app/_models/patient';

@Component({
  selector: 'app-patient-list-item',
  templateUrl: './patient-list-item.component.html',
  styleUrls: ['./patient-list-item.component.css']
})
export class PatientListItemComponent implements OnInit {
  @Input() patient!: Patient;

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  navigateToPatient() {
    this.router.navigateByUrl('patient/' + this.patient.uiId);
  }

}
