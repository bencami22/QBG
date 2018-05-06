import { Injectable, Inject } from '@angular/core';
import { QueueGet } from './QueueGet';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class QueueService {

  private baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  getQueues(): Observable<QueueGet[]> {
    return this.http.get<QueueGet[]>(this.baseUrl + 'api/queue');
  }
}
