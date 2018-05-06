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
    this.queueService.getQueues()
      .subscribe(result => { this.queueGet = result; },
        error => { console.error(error); }
      );
  }
}
