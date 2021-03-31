import { Component, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: 'app-health-check',
  templateUrl: './health-check.component.html',
  styleUrls: ['./health-check.component.css']
})

export class HealthCheckComponent {
  public healthChecks: HealthChecks;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  ngOnInit() {
    this.http.get<HealthChecks>(this.baseUrl + 'health-checks').subscribe(response => {
        this.healthChecks = response;
      },
      error => {
        debugger;
        console.error(error);
      });
  }
}


interface HealthChecks {
  checks: HealthCheck;
  totalStatus: string;
  totalResponseTime: number;
}

interface HealthCheck {
  name: string;
  status: string;
  responseTime: number;
}
