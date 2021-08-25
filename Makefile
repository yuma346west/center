run:
	docker-compose up -d app db
run-all:
	docker-compose up -d
down:
	docker-compose down
login:
	docker exec -it center_app /bin/sh
ps:
	docker ps