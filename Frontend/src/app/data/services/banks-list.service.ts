import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BanksListService {
  
  private http = inject(HttpClient);
  
  getBanks(){
    return this.http.get('https://localhost:7197/api/BankApi');
  }

}
