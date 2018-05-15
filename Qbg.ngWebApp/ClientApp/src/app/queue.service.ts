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

  getQueue(id: number): Observable<QueueGet> {
    return this.http.get<QueueGet>(this.baseUrl + 'api/queue/' + id);
  }

  enqueue(queueId: number, username: string) {
    const body = {Id: queueId , UserName: username };
    return this.http.post(this.baseUrl + 'api/queue/enqueue', body);
  }

  dequeue(id: number) {
    return this.http.post(this.baseUrl + 'api/queue/dequeue?id=' + id, null);
  }

  createQueue() {
    return this.http.post(this.baseUrl + 'api/queue', null);
  }

  deleteQueue(id: number) {
    return this.http.delete(this.baseUrl + 'api/queue/' + id);
  }
}
