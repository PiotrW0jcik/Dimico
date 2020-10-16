import { PlanService } from './../services/plan.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-createpost',
  templateUrl: './createpost.component.html',
  styleUrls: ['./createpost.component.css']
})
export class CreatepostComponent {
  planForm: FormGroup;
  constructor(private fb: FormBuilder, private planService: PlanService) {
    this.planForm = this.fb.group({
      'ImageUrl' : ['', Validators.required],
      'Description' : ['']
    });
  }



  get imageUrl(){
    return this.planForm.get('ImageUrl');
  }

  create(){
    this.planService.create(this.planForm.value).subscribe(res => {
      console.log(res);
    });
  }


}
