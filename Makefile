run-wiki:
	docker-compose up -d wiki db
run-js:
	docker-compose up -d nestjs
run-nextjs:
	docker-compose up -d nextjs
run-all:
	docker-compose up -d
down:
	docker-compose down
login:
	docker exec -it project-center_wiki_1 /bin/sh
login-nextjs:
	docker exec -it nextjs /bin/sh
ps:
	docker ps
