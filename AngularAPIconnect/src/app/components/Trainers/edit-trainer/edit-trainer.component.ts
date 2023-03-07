import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Trainers } from 'src/app/models/trainers.model';
import { EmpService } from 'src/app/services/emp.service';

@Component({
  selector: 'app-edit-trainer',
  templateUrl: './edit-trainer.component.html',
  styleUrls: ['./edit-trainer.component.css']
})
export class EditTrainerComponent implements OnInit{

  trainerDetails:Trainers ={
    id:0,
    firstName:'',
    lastName:'',
    gender:'',
    email:'',
    password:'',
    phone:'',
    city:'',
    state:'',
    country:'',
    aboutme:''
  };
  constructor(private route:ActivatedRoute,private trainerservice:EmpService,private router:Router){}
  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next:(params)=>{
        const e=params.get('email');
        const p=params.get('password');

        if(e && p){
          this.trainerservice.getTrainer(e,p)
          .subscribe({
            next:(response)=>{
              this.trainerDetails=response;
            }
          })
        }

      }
    })
  }
  updateTrainer(){
    this.trainerservice.updateTrainer(this.trainerDetails.email,this.trainerDetails)
    .subscribe({
      next:(response)=>{
        this.router.navigate(['/trainer']);
      }

    })
  };

}
