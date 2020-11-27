import { AuthService } from './../services/auth.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  constructor(private fb: FormBuilder, private authService: AuthService,private router :Router) {
    this.registerForm = this.fb.group({
      'username': [ '', Validators.required],
      'email': [ '', Validators.required],
      'password': [ '', Validators.required] ,
    });
   }

  ngOnInit(): void {
  }
  register(){
    this.authService.register(this.registerForm.value).subscribe(data => {
      console.log(data);
      this.router.navigate(["profile/edit"]);
    });
  }

  get username(){
    return this.registerForm.get('username');
  }
  get email(){
    return this.registerForm.get('email');
  }
  get password(){
    return this.registerForm.get('password');
  }


}
