import { useState } from "react";
import { Switch, Route } from "react-router";
import { BrowserRouter } from "react-router-dom";

import LoginForm from "./components/Login/LoginForm";
import Posts from "./components/Posts/Posts";
import Users from "./components/Users/Users";

function App() {

  const adminUser = {
    email: "admin@source.no",
    password: "Admin123."
  }

  const [user, setUser] = useState({ email: "" });
  const [error, setError] = useState("");

  const Login = (details) => {
    if (details.email === adminUser.email && details.password === adminUser.password) {
      setUser({
        email: details.email
      });
    }
    else {
      setError("Wrong email or password");
    }
  }

  const Logout = () => {
    setUser({ email: "" });
  }

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
