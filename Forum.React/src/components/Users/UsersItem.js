import React from 'react'
import { Link } from 'react-router-dom';
import { Button } from 'reactstrap'

const UsersItem = ({ item}) => {

    return (
        <tr>
            <td>{item.id}</td>
            <td>{item.name}</td>
            <td>{item.username}</td>
            <td>{item.website}</td>
            <td><Link to={`/posts/${item.id}`}><Button color="primary">Posts</Button></Link></td>
        </tr>
    )
}

export default UsersItem
