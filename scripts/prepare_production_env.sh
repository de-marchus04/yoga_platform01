#!/usr/bin/env bash

set -euo pipefail

target_file="${1:-.env}"

if [[ -f "${target_file}" ]]; then
  echo "Refusing to overwrite existing ${target_file}." >&2
  exit 1
fi

jwt_secret="$(tr -dc 'A-Za-z0-9' < /dev/urandom | head -c 64)"
postgres_password="$(tr -dc 'A-Za-z0-9' < /dev/urandom | head -c 32)"

cat > "${target_file}" <<EOF
# PostgreSQL
POSTGRES_USER=postgres
POSTGRES_PASSWORD=${postgres_password}
POSTGRES_DB=YogaLifeEnterpriseDb

# JWT
JWT_SECRET_KEY=${jwt_secret}
JWT_ISSUER=YogaEnterpriseApi
JWT_AUDIENCE=YogaEnterpriseClient

# Public origin for API CORS in production
APP_ORIGIN=https://medisha.space

# Telegram Notifications
TELEGRAM_BOT_TOKEN=
TELEGRAM_CHAT_ID=
EOF

chmod 600 "${target_file}"

echo "Created ${target_file}. Review and update optional values before starting the stack."