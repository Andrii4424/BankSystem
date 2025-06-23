import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './common-ui/header-component/header-component';
import { BankCardsComponent } from './bank-info-ui/bank-list-component/bank-list-component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HeaderComponent, BankCardsComponent],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected title = 'BankFrontend';
}
