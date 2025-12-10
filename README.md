# sendion
Sendion is a modular library implementing the Outbox pattern, designed to solve the "dual-write" problem in distributed systems. It guarantees eventual consistency between your database changes and your event bus by persisting messages within a transaction before publishing them.
