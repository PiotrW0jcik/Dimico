import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Plan } from '../models/Plan';
import { PlanService } from '../services/plan.service';
import { map, mergeMap } from 'rxjs/operators';

@Component({
  selector: 'app-details-plan',
  templateUrl: './details-plan.component.html',
  styleUrls: ['./details-plan.component.css']
})
export class DetailsPlanComponent implements OnInit {
  id: string;
  plan: Plan;
  constructor(private route: ActivatedRoute, private planService: PlanService) { 
    // this.route.params.subscribe(res =>{
    //   this.id = res['id'];
    //   this.planService.getPlan(this.id).subscribe(res =>{
    //     this.plan = res;
    //   })
    //})
    this.fetchData()
  }
  fetchData(){
    this.route.params.pipe(map( params => {
      const id = params ['id'];
      return id;
    }), mergeMap(id => this.planService.getPlan(id))).subscribe(res => {
      this.plan = res;
    })
  }

  ngOnInit(): void {
    console.log("hi")
  }

}