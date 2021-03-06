import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonalBoardComponent } from './personal-board.component';

describe('PersonalBoardComponent', () => {
  let component: PersonalBoardComponent;
  let fixture: ComponentFixture<PersonalBoardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PersonalBoardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonalBoardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
