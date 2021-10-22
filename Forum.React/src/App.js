import {Route } from "react-router";
import { BrowserRouter } from "react-router-dom";

import LoginForm from "./components/Login/LoginForm";
import Posts from "./components/Posts/Posts";
import Users from "./components/Users/Users";

function App() {

  return (
    <div className="App">
      <BrowserRouter>

          <Route exact path="/">
            <LoginForm></LoginForm>
          </Route>

          <Route path="/users" exact component={Users}></Route>

          <Route path='/posts/:id' exact component={Posts}>

          </Route>

      </BrowserRouter>
    </div>


  );
}

export default App;
