import React, {useState} from 'react'
import { Button, Form, FormGroup, Label, Input} from 'reactstrap';
import { Redirect } from 'react-router';

import classes from './LoginForm.Module.css'
import { environment } from '../../Environments';


const LoginForm = () => {

    const[username,setUsername]=useState('');
    const[password,setPassword]=useState('');
    const[redirect,setRedirect]=useState(false);
    const[error, setError] = useState('');

    const submitHandler=async (e)=>{
        e.preventDefault();

        const user=await fetch(environment.API_Url+'users/authenticate',{
            method: 'POST',
            headers:{'Content-Type':'application/json'},
            credentials:'include',
            
            body:JSON.stringify({
                username,
                password
            })
        });

        if(user.ok===true){
        setRedirect(true);
        }
        else{
            setError("Wrong credentials");
        }
    }

    if(redirect){
        return <Redirect to="/users"></Redirect>
    }

    return (
        <div>
            <Form  className={classes.loginForm} onSubmit={submitHandler}>
                <h2>Login</h2>
                {(error!=="")?(<div className={classes.error}>{error}</div>):""}
                <FormGroup className={classes.formGroup}>
                    <Label for="username">Username</Label>
                    <Input type="text" name="username" id="username" onChange={e=> setUsername(e.target.value)}/>
                </FormGroup>

                <FormGroup  className={classes.formGroup}> 
                    <Label for="password">Password</Label>
                    <Input type="password" name="password" id="password" onChange={e=> setPassword(e.target.value)} />
                </FormGroup>

                <FormGroup  className={classes.formGroup}>
                    <Button className="btn" color="primary" type="submit">Log in</Button>
                </FormGroup>
            </Form>
        </div>
    )
}

export default LoginForm
