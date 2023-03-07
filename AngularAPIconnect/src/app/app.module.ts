import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TrainersListComponent } from './components/Trainers/trainers-list/trainers-list.component';
import { AddTrainersComponent } from './components/Trainers/add-trainers/add-trainers.component';
import { FormsModule } from '@angular/forms';
import { EditTrainerComponent } from './components/Trainers/edit-trainer/edit-trainer.component';


@NgModule({
  declarations: [
    AppComponent,
    TrainersListComponent,
    AddTrainersComponent,
    EditTrainerComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
