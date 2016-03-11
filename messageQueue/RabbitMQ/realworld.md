### when connect to a RabbitMQ, you need to consider when RabbitMQ is failed, how should you do? will you need to reconnect?


### edge cases, no queue was binding to an exchange
* be sure queue exists in any case(so declare the queue at any time before you uisng them. this operation is idempotent)
