import { Component, inject } from '@angular/core';
import { BanksListService } from '../../data/services/banks-list.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-bank-cards-component',
  imports: [CommonModule],
  templateUrl: './bank-list-component.html',
  styleUrl: './bank-list-component.scss'
})
export class BankCardsComponent {
  bankListService = inject(BanksListService);

  banks:any =[]

  constructor(){
    this.bankListService.getBanks()
      .subscribe(val=>{
        console.log(val);
        this.banks = val
      });
  }
}
