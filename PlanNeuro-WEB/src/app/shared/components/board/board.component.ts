import {Component, Input, OnDestroy, OnInit} from '@angular/core';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.css']
})
export class BoardComponent implements OnInit, OnDestroy {
 // @Input() boardId: number;

  constructor() {
  }

  ngOnInit() {
  }

  ngOnDestroy(): void {
  }

}
