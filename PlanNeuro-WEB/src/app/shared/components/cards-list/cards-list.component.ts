import {Component, Input, OnInit} from '@angular/core';
import {CardsListModel} from '../../models/cards-list.model';

@Component({
  selector: 'app-cards-list',
  templateUrl: './cards-list.component.html',
  styleUrls: ['./cards-list.component.css']
})
export class CardsListComponent implements OnInit {
  @Input() cardsList: CardsListModel;

  constructor() {
  }

  ngOnInit() {
  }

}
