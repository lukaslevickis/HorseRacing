import { Component, OnInit } from '@angular/core';
import { Better } from 'src/app/models/better';
import { BetterService } from 'src/app/services/better.service';
import { FormBuilder } from '@angular/forms';
import { HorseService } from 'src/app/services/horse.service';
import { Horse } from 'src/app/models/horse';

@Component({
  selector: 'app-better',
  templateUrl: './better.component.html',
  styleUrls: ['./better.component.css']
})

export class BetterComponent implements OnInit {
  private betterService: BetterService;
  private horseService: HorseService;
  public betters: Better[] = [];
  public horses: Horse[] = [];
  update: boolean = false;
  horseId: number = null as any;
  horseId2: number = 0;
  bet: number = null as any;
  betterId: number = null as any;
  name: string = '';
  surname: string = '';

  postData = {} as Better;
  betterForm = this.formBuilder.group({
    name: '',
    surname: '',
    bet: null,
    horseId: null,
    about: '',
  });

  constructor(betterService: BetterService, 
              horseService: HorseService, 
              private formBuilder: FormBuilder) { 
    this.betterService = betterService;
    this.horseService = horseService;
   }

   async ngOnInit(): Promise<void> {
    await this.getHorses();
    await this.getBetters();
  }

  addBetter(): void {
    this.postData.id = this.betterForm.value.id;
    this.postData.name = this.betterForm.value.name;
    this.postData.surname = this.betterForm.value.surname;
    this.postData.bet = this.betterForm.value.bet;
    this.postData.horseId = this.betterForm.value.horseId;
    this.betterService.addBetter(this.postData).subscribe(newBetter => {
      newBetter.horseName = this.assignHorseName(newBetter.horseId);
      this.betters.push(newBetter);
      this.betters.sort((a, b) => (a.bet < b.bet) ? 1 : -1);
      this.resetFormValues();
    });
  }

  deleteBetter(id: number): void {
    this.betterService.deleteBetter(id).subscribe(() => {
      this.betters = this.betters.filter(x => x.id != id);
    });
  }

  public async getBetters(): Promise<void> {
    let betters = await this.betterService.getBetters().toPromise();
    betters.forEach(r => r.horseName = this.assignHorseName(r.horseId));
    this.betters = betters;
  }

  private assignHorseName(horseId: number | null): string {
    if (horseId === null) return '';
    return this.horses.filter(d => d.id == horseId)[0].name;
  }

  public async getHorses(): Promise<void> {
    let horses = await this.horseService.getHorses().toPromise();
    this.horses = horses;
  }

  horseUpdated(value: string): void {
    this.getHorses();
  }

  loadValuesToForm(better: Better): void {
    this.betterId = better.id;
    this.name = better.name;
    this.surname = better.surname;
    this.bet = better.bet;
    this.horseId = better.horseId;
    this.update = true;
  }

  updateBetter(): void {
    this.postData.id = this.betterId;
    this.postData.name = this.name;
    this.postData.surname = this.surname;
    this.postData.bet = this.bet;
    this.postData.horseId = this.horseId;
    this.betterService.updateBetter(this.postData).subscribe(updatedBetter => {
      updatedBetter.horseName = this.assignHorseName(updatedBetter.horseId);
      let index = this.betters.map(e => e.id).indexOf(updatedBetter.id);
      this.betters[index] = updatedBetter;
      this.betters.sort((a, b) => (a.bet < b.bet) ? 1 : -1);
      this.resetFormValues();
    });
  }

  resetFormValues(): void {
    this.betterId = null as any;
    this.name = '';
    this.surname = '';
    this.bet = null as any;
    this.horseId = null as any;
    this.update = false;
  }

  filterTable(id: number): void {
    if (id == 0) {
      this.getBetters();
    } else {
      this.betterService.getHorseBetters(id).subscribe((bettersFromApi) => {
        bettersFromApi.forEach(r => r.horseName = this.assignHorseName(r.horseId));
        this.betters = bettersFromApi;
      });
    }
  }

}