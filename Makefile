run:
	docker-compose up -d wiki db
run-all:
	docker-compose up -d
down:
	docker-compose down
login:
	docker exec -it project-center_wiki_1 /bin/sh
ps:
	docker ps
