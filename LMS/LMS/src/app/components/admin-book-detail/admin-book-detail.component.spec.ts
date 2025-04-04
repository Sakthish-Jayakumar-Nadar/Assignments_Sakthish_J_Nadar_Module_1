import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminBookDetailComponent } from './admin-book-detail.component';

describe('AdminBookDetailComponent', () => {
  let component: AdminBookDetailComponent;
  let fixture: ComponentFixture<AdminBookDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdminBookDetailComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminBookDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
