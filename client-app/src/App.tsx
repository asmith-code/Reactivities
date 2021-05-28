import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';

function App() {

  const [activities, setActivities] = useState([]); /** activities (variable to store state) - then function to set the state -
  use state hook - intially set to empty array */

  useEffect(() => {/** use effect hook - empty function as send HTTP request 
    - waits for data so we use 'then' for what to do after activities received*/
    axios.get('http://localhost:5000/api/activities').then(response => {
      console.log(response);  
      setActivities(response.data);
    })
  }, []) /**when we set activities - activities state is changed which causes
  a re-render which means useEffect runs again - causing an infinite route - []
  required to prevent this */

  return (
    <div>
      <Header as='h2' icon='users' content='Reactivities' />
       <List>
       {activities.map((activity: any) => ( /**curly brackets means javascript
         - loop through activities - key needed to loop - activity 'any' for any type */
           <List.Item key={activity.id}> 
             {activity.title} 
           </List.Item>
         ))}
       </List>
    </div>
  );
}

export default App;
