const url = 'https://localhost:7222/api/Workout'
async function handleOnLoad()
{
   const response = await fetch("https://localhost:7222/api/Workout")
   const workouts = await response.json();
  console.log(workouts);
   let html=`
   <h1>Welcome to TideFit<h1>
   <div id='tableBody'></div>

<form onsubmit="return false">
  <label for="activity">Activity:</label><br>
  <input type="text" id="activity" name="activity"><br>
  <label for="date">Date:</label><br>
  <input type="date" id="date" name="date"><br>
  <label for="distance">Distance(miles):</label><br>
  <input type="text" id="distance" name="distance">
  <button onclick="handleWorkoutAdd()" class="btn btn-primary">Submit</button>
</form>`;
document.getElementById('app').innerHTML=html;
PopulateTable();
}
async function HandleWorkoutAdd()
{

}
async function PopulateTable()
{
    fetch(url).then(function(response){
        console.log(response)
        return response.json()
    }).then(function(json){
        console.log(json)
        displayWorkoutTable(json)
    })
}
function displayWorkoutTable(json)
{

   console.log(json)
   console.log(json[1].type)
   json.sort((a,b) => b.date - a.date)
   let html=`
    <table class="table">
         <tr>
           <th>Activity</th>
           <th>Date</th>
           <th>Distance</th>
           <th>Pin</th>
           <th>Delete</th>
         </tr>`;
         json.forEach(function(activity)
         {

            if (!activity.pinned && !activity.deleted)
            {
         html += `
                <tr class = "table-light">
                
                <td>${activity.type}</td>
                <td>${activity.date}</td>
                <td>${activity.distance}</td>
                <td><button class="btn btn-warning" onclick="handleWorkoutPin('${activity.id}')">Pin</button></td>
                <td><button class="btn btn-danger" onclick="handleWorkoutDelete('${activity.id}')">Delete</button></td>
                </tr>`;
            }
            else if (activity.pinned && !activity.deleted)
            {
                html += `
                <tr class = "table-warning">
                
                <td>${activity.type}</td>
                <td>${activity.date}</td>
                <td>${activity.distance}</td>
                <td><button class="btn btn-warning" onclick="handleWorkoutUnpin(${activity.id})">Unpin</button></td>
                <td><button class="btn btn-danger" onclick="handleWorkoutDelete(${activity.id})">Delete</button></td>
                </tr>`;
            }
         })
        
         html+=`</table>`
         document.getElementById('tableBody').innerHTML = html;
   html+=`</table>`
   document.getElementById('tableBody').innerHTML = html;
}

async function handleWorkoutAdd()
{
    let workout = {Type: document.getElementById('activity').value , Date: document.getElementById('date').value , Distance: document.getElementById('distance').value, Pinned: false}
   await fetch(url, {
      method: "POST",
      headers: {
         "Content-Type": "application/json"
      },
      body: JSON.stringify(workout)
   })
    PopulateTable();
    document.getElementById('activity').value = ' ';
    document.getElementById('date').value = 'yyyy-MM-dd';
    document.getElementById('distance').value = ' ';
}
async function handleWorkoutPin(id)
{
   //isnt pinned, sends true so it gets pinned
   let workout = {Id: id, Pinned: true}
   await fetch(url, {
      method: "PUT",
      headers: {
         "Content-Type": "application/json"
      },
      body: JSON.stringify(workout)
   })
   PopulateTable();
}

async function handleWorkoutUnpin(id)
{ 
   //is pinned, sends false to unpin
   let workout = {Id: id, Pinned: false}
   await fetch(url, {
      method: "PUT",
      headers: {
         "Content-Type": "application/json"
      },
      body: JSON.stringify(workout)
   })
   PopulateTable();
}

async function handleWorkoutDelete(id)
{
   let workout = {Id: id, Deleted: true}
   await fetch(url, {
      method: "DELETE",
      headers: {
         "Content-Type": "application/json"
      },
      body: JSON.stringify(workout)
   })
   PopulateTable();
}