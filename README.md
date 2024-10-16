# WebAPI Practice Projects
專案基本描述
RESTful API set  
已經有兩個預設 GET API  
GET /todos, 取得所有的 todos  
GET /todos/{id}, 取得特定 id 的 todos  

public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);

1. 擴充一個 POST API /todos 透過 body 可以建立一個 todo
2. 擴充一個 PUT API /todos/{id} 加上 body 可以修改特定一個 todo 的內容
3. 擴充一個 DELETE API /todos/{id} 可以刪除特定一個 todo
4. 擴充一個 POST API /todos/title={title}&dueby={dueby}&iscomplete={iscomplete} 不透過 body, 反而透過 query 來建立一個 todo 內容 
5. 擴充一個 GET API /search/{title} 可以取得符合的 titles
