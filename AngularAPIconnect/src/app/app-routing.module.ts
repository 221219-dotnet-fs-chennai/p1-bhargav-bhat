import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddTrainersComponent } from './components/Trainers/add-trainers/add-trainers.component';
import { EditTrainerComponent } from './components/Trainers/edit-trainer/edit-trainer.component';
import { TrainersListComponent } from './components/Trainers/trainers-list/trainers-list.component';

const routes: Routes = [
  {
    path:'trainer',
    component:TrainersListComponent
  },
  {
    path:'trainer/add',
    component:AddTrainersComponent
  },
  {
    path:'trainer/edit/:email/:password',
    component:EditTrainerComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
