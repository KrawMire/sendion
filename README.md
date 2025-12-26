<p align="center">
  <img src="https://raw.githubusercontent.com/KrawMire/sendion/main/docs/assets/sendion-logo.background.png" alt="Title image" />
</p>

Sendion is a modular library implementing the Outbox pattern, designed to solve the "dual-write" problem in distributed systems.
It guarantees eventual consistency between your database changes and your event bus by persisting messages within a transaction before publishing them.

## Supported Persistence Providers

Sendion supports the following persistence providers:

- MongoDB;
- PostgreSQL.

## Supported Transport Providers

Sendion supports the following persistence providers:

- Kafka.
