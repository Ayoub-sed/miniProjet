import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChambreFroideComponent } from './chambre-froide.component';

describe('ChambreFroideComponent', () => {
  let component: ChambreFroideComponent;
  let fixture: ComponentFixture<ChambreFroideComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChambreFroideComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChambreFroideComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
