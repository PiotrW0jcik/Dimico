import { AuthService } from './../services/auth.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  constructor(private fb: FormBuilder, private AuthService: AuthService) {
    this.loginForm = this.fb.group({
      'username': [ '', Validators.required ],
      'password': [ '', Validators.required ]
    });
  }

  ngOnInit(): void {
  }

  login(){
    this.AuthService.login(this.loginForm.value).subscribe(data => {
      this.AuthService.saveToken(data['token']);
    });
  }

  get username(){
    return this.loginForm.get('username');
  }

  get password(){
    return this.loginForm.get('password');
  }

}
