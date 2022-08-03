import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { LoginComponent } from "./login/login.component";
import { PatientListComponent } from "./patient-list/patient-list.component";
import { PatientViewComponent } from "./patient-view/patient-view.component";
import { AuthGuard } from "./_auth/auth.guard";

const appRoutes: Routes = [
    { path: '', component: LoginComponent },
    { path: 'patients', component: PatientListComponent, canActivate: [AuthGuard] },
    { path: 'patient/:id', component: PatientViewComponent, canActivate: [AuthGuard]  }
  ];
  
  @NgModule({
    declarations: [],
    imports: [
      RouterModule.forRoot(appRoutes)
    ],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }