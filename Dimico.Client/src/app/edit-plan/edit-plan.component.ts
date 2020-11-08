import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Plan } from '../models/Plan';
import { PlanService } from '../services/plan.service';

@Component({
  selector: 'app-edit-plan',
  templateUrl: './edit-plan.component.html',
  styleUrls: ['./edit-plan.component.css']
})
export class EditPlanComponent implements OnInit {
  planForm: FormGroup;
  planId: string;
  plan: Plan;
  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private planService: PlanService,
    private router: Router,
     ) 
     { 
       this.planForm = this.fb.group({
        'id': [''],
        'description': [''],
       })
     }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.planId = params['id'];
      this.planService.getPlan(this.planId).subscribe(res => {
        this.plan = res;
        this.planForm = this.fb.group({
          'id': [this.plan.id],
          'description': [this.plan.description],
       })
      })
    })
  }

  editPlan() {
    this.planService.editPlan(this.planForm.value).subscribe(res => {
      this.router.navigate(["plans"]);
    })
  }

}
