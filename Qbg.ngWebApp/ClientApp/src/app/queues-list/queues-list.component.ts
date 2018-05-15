import { Component, Inject } from '@angular/core';

import { QueueService } from '../queue.service';
import { QueueGet } from '../QueueGet';
import 'rxjs/add/operator/map';

@Component({
  selector: 'app-queues-list',
  templateUrl: './queues-list.component.html',
  providers: [QueueService]
})
export class QueuesListComponent {
  public queueGet: QueueGet[];

  constructor(private queueService: QueueService) { }

  // tslint:disable-next-line:use-life-cycle-interface
  ngOnInit() {
    this.refresh();
  }

  createQueue() {
    this.queueService.createQueue()
    .subscribe(result => {console.log(result); this.refresh(); },
    error => {console.error(error); });
  }

  deleteQueue(id: number) {
    this.queueService.deleteQueue(id)
    .subscribe(result => {console.log(result); this.refresh(); },
    error => {console.error(error); });
  }

  refresh(): void {
    this.queueService.getQueues()
      .subscribe(result => { this.queueGet = result; },
        error => { console.error(error); }
      );
  }
}
