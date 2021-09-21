require('dotenv').config()

module.exports =
    {
        "development": {
            "username": "root",
            "password": null,
            "database": "common",
            "host": "127.0.0.1",
            "dialect": "mysql"
        },
        "local": {
            "username": "app_user",
            "password": "password",
            "database": "common",
            "host": "mysql_host",
            "dialect": "mysql"
        },
        "production": {
            "username": "root",
            "password": null,
            "database": "database_production",
            "host": "127.0.0.1",
            "dialect": "mysql"
        }
    }