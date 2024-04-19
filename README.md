# ASELSAN Assessment

### Restaurant Menu List / Order Project

.Net 8.0, PostgreSQL, EFCore 8, Microsoft Dependency Injection

# Sample Data

*check dbDump.sql*

### Category

| ID                                   | Name   |
|--------------------------------------|--------|
| 070e119a-fcb5-4a40-9ae7-be48e08f6d37 | Foods  |
| 9020fda2-ade5-4140-9699-e14bc418ce44 | Drinks |
| aab10325-9fa6-4eb1-ad87-65e8a7fb5699 | Soup   |
| e9298e20-67de-49e7-b5cf-6c1141422cef | Snacks |

### Customer

| ID                                   | Description |
|--------------------------------------|-------------|
| 2efda96f-7303-4160-9798-62745cdf3139 | Balkon-1    |
| c1637f94-7ab0-400f-852c-41f0ce3d0fa0 | Balkon-2    |
| 34ed13e2-2a93-4b1b-9a50-0cab68637ebf | Salon-1     |
| c2cc338d-91fb-470e-8e1c-2160c21b141d | Salon-2     |
| d80a6462-4795-42ce-9e38-ced4a083c791 | Salon-3     |

### MenuItem

| ID                                   | CategoryID                           | Name    | Description  | Price | IsPermanent | IsActive | GlutenFree | IsVegan | CreateDate                    | DayOfWeek |
|--------------------------------------|--------------------------------------|---------|--------------|-------|-------------|----------|------------|---------|-------------------------------|-----------|
| 31f13d31-e2ae-4f75-b122-85cd772a8894 | 070e119a-fcb5-4a40-9ae7-be48e08f6d37 | Patates | Patates , su | 14    | 0           | 1        | 1          | 1       | 2024-04-19 22:18:38.250339+03 | 0         |
| 8e515c45-3443-4857-979b-e5eb2ac6ef91 | e9298e20-67de-49e7-b5cf-6c1141422cef | Meze    | nohut, su    | 1     | 1           | 1        | 0          | 1       | 2024-04-19 23:09:32.723485+03 | [null]    |

### Order

| ID                                   | CustomerID                           | MenuItemID                           | Count | OrderDate                     | OrderNote | IsChecked |
|--------------------------------------|--------------------------------------|--------------------------------------|-------|-------------------------------|-----------|-----------|
| b9244d43-572c-4335-a37b-afa83fdabc5b | d80a6462-4795-42ce-9e38-ced4a083c791 | 31f13d31-e2ae-4f75-b122-85cd772a8894 | 2     | 2024-04-19 22:45:44.959972+03 |           | 1         |
