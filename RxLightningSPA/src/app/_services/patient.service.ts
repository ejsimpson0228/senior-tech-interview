import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PatientService {
  patientsUrl = environment.APIBaseUrl + 'patients/';

  constructor(private http: HttpClient) { }

  getPatients() {
    return this.http.get(this.patientsUrl);
  }

  getPatient(id: number) {
    return this.http.get(this.patientsUrl + id);
  }
}
