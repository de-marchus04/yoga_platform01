#!/bin/bash
docker exec yoga-postgres psql -U postgres -d YogaLifeEnterpriseDb -c "INSERT INTO \"__EFMigrationsHistory\" (\"MigrationId\", \"ProductVersion\") VALUES ('20260321154049_AddLockoutColumnsToCustomers', '8.0.0') ON CONFLICT DO NOTHING;"
docker restart yoga-api
echo "Done! API restarting..."
