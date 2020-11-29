import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Profile } from '../models/Profile';
import { ProfileService } from '../services/profile.service';

@Component({
  selector: 'app-details-profile',
  templateUrl: './details-profile.component.html',
  styleUrls: ['./details-profile.component.css']
})
export class DetailsProfileComponent implements OnInit {
  profile : Profile
  constructor(private profileService: ProfileService, private router: Router ) {}

  ngOnInit(): void {
    this.fetchProfile()
   }
   fetchProfile() {
     this.profileService.getProfile().subscribe(profile => {
       this.profile = profile;
       console.log(this.profile)
     })
   }
   editProfile(){
    this.router.navigate(["profile","edit"]);
  }
 

  
}
