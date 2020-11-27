import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ProfileService } from '../services/profile.service';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css']
})
export class EditProfileComponent {
  profileForm: FormGroup;
  types: number[] = [0,1];
  constructor(private fb: FormBuilder, private profileService: ProfileService,private toastrService: ToastrService) {
    this.profileForm = this.fb.group({
      'MainPhotoUrl' : [''],
      'Gender' : [''],
      'Biography' : [''],
      'Email' : [''],
      'WebSite' : [''],
      'IsPrivate' : [''], 
      'UserName' : [''],
      'Name' : ['']
    })
  
}
create(){
  console.log(this.profileForm.value);
  this.profileService.create(this.profileForm.value).subscribe(res => {
    this.toastrService.success("Success")
    console.log(res);
  })}}
