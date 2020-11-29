import { CreateplanComponent } from './createplan/createplan.component';
import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuardService } from './services/auth-guard.service';
import { ListPlansComponent } from './list-plans/list-plans.component';
import { DetailsPlanComponent } from './details-plan/details-plan.component';
import { EditPlanComponent } from './edit-plan/edit-plan.component';
import { DetailsProfileComponent } from './details-profile/details-profile.component';
import { EditProfileComponent } from './edit-profile/edit-profile.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'create' , component: CreateplanComponent, canActivate: [AuthGuardService]},
  { path: 'plans', component: ListPlansComponent, canActivate: [AuthGuardService]},
  { path: 'plans/:id', component: DetailsPlanComponent, canActivate: [AuthGuardService]},
  { path: 'plans/:id/edit', component: EditPlanComponent , canActivate: [AuthGuardService]},
  { path: 'profile', component: DetailsProfileComponent, canActivate: [AuthGuardService]},
  { path: 'profile/edit', component: EditProfileComponent, canActivate: [AuthGuardService] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
