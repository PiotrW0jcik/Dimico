import { PlanService } from '../services/plan.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-createplan',
  templateUrl: './createplan.component.html',
  styleUrls: ['./createplan.component.css']
})
export class CreateplanComponent {
  planForm: FormGroup;
  types: number[] = [0,1];
  constructor(private fb: FormBuilder, private planService: PlanService,private toastrService: ToastrService) {
    this.planForm = this.fb.group({
      'ImageUrl' : ['', Validators.required],
      'Type' : [''],
      'Description' : ['']
    })
  }

 

  get imageUrl(){
    return this.planForm.get('ImageUrl');
  }


  create(){
    console.log(this.planForm.value);
    this.planService.create(this.planForm.value).subscribe(res => {
      this.toastrService.success("Success")
      console.log(res);
    });
  }


}
