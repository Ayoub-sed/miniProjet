import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostUpdateFraisInterventionComponent } from './post-update-frais-intervention.component';

describe('PostUpdateFraisInterventionComponent', () => {
  let component: PostUpdateFraisInterventionComponent;
  let fixture: ComponentFixture<PostUpdateFraisInterventionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PostUpdateFraisInterventionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PostUpdateFraisInterventionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
