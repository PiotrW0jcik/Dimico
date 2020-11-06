import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Plan } from '../models/Plan';
import { PlanService } from '../services/plan.service';

@Component({
  selector: 'app-list-plans',
  templateUrl: './list-plans.component.html',
  styleUrls: ['./list-plans.component.css']
})
export class ListPlansComponent implements OnInit {
  plans: Array<Plan>
  constructor(private planService: PlanService,private router: Router){ }

  ngOnInit(): void {
    this.planService.getPlans().subscribe(plans => {
      this.plans = plans;
      console.log(this.plans)
    })
  }

}
