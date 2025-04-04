import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminRequestComponent } from './admin-request.component';

describe('AdminRequestComponent', () => {
  let component: AdminRequestComponent;
  let fixture: ComponentFixture<AdminRequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdminRequestComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
