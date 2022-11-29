import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChooseFilialeForEquipementsComponent } from './choose-filiale-for-equipements.component';

describe('ChooseFilialeForEquipementsComponent', () => {
  let component: ChooseFilialeForEquipementsComponent;
  let fixture: ComponentFixture<ChooseFilialeForEquipementsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChooseFilialeForEquipementsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChooseFilialeForEquipementsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
