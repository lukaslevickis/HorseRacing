import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Horse } from 'src/app/models/horse';
import { HorseService } from 'src/app/services/horse.service';

@Component({
  selector: 'app-horse',
  templateUrl: './horse.component.html',
  styleUrls: ['./horse.component.css']
})
export class HorseComponent implements OnInit {
  @Output() onHorseUpdated = new EventEmitter();
  private horseService: HorseService;
  horses: Horse[];
  update: boolean = false;
  horseId: number = null as any;
  name: string = '';
  runs: number = null as any;
  wins: number = null as any;
  about: string = '';

  postData = {} as Horse;
  horseForm = this.formBuilder.group({
    name: '',
    runs: null,
    wins: null,
    about: null
  });

  constructor(horseService: HorseService, private formBuilder: FormBuilder) { 
    this.horseService = horseService;
   }

  ngOnInit(): void {
    this.horseService.getHorses().subscribe((horsesFromApi) =>{
      this.horses = horsesFromApi;
    })
  }

  addHorse(): void {
    this.postData.id = this.horseForm.value.id;
    this.postData.name = this.horseForm.value.name;
    this.postData.runs = this.horseForm.value.runs;
    this.postData.wins = this.horseForm.value.wins;
    this.postData.about = this.horseForm.value.about;
    this.horseService.addHorse(this.postData).subscribe(newHorse => {
      this.horses.push(newHorse);
      this.horses.sort((a, b) => (a.name.toLowerCase() > b.name.toLowerCase()) ? 1 : -1);
      console.log(this.horses);
      this.resetFormValues();
      this.onHorseUpdated.emit("");
    });
  }

  deleteHorse(id: number): void {
    this.horseService.deleteHorse(id).subscribe(() => {
      this.horses = this.horses.filter(x => x.id != id);
    });
  }

  loadValuesToForm(horse: Horse): void {
    this.horseId = horse.id;
    this.name = horse.name;
    this.runs = horse.runs;
    this.wins = horse.wins;
    this.about = horse.about;
    this.update = true;
  }

  updateHorse(): void {
    this.postData.id = this.horseId;
    this.postData.name = this.name;
    this.postData.runs = this.runs;
    this.postData.wins = this.wins;
    this.postData.about = this.about;
    this.horseService.updateHorse(this.postData).subscribe(updatedHorse => {
      let index = this.horses.map(e => e.id).indexOf(updatedHorse.id);
      this.horses[index] = updatedHorse;
      this.horses.sort((a, b) => (a.name.toLowerCase() > b.name.toLowerCase()) ? 1 : -1);
      this.resetFormValues();
    });
  }

  resetFormValues(): void {
    this.horseId = null as any;
    this.name = '';
    this.runs = null as any;
    this.wins = null as any;
    this.about = '';
    this.update = false;
  }

}