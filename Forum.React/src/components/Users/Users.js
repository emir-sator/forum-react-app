import React, { useState, useEffect } from 'react';
import { Button, Table, Row, Col, FormGroup, Input, Pagination, PaginationItem, PaginationLink } from 'reactstrap'
import _ from 'lodash'

import classes from './Users.Module.css'
import UsersItem from './UsersItem';
import { environment } from '../../Environments';
import { Link } from 'react-router-dom';

const Users = () => {

    const [users, setUsers] = useState([]);
    const [paginatedUsers, setPaginetedUsers] = useState([]);
    const [searchedUsers, setSearchedUsers] = useState([]);
    const [currentPage, setCurrentPage] = useState(1);
    const [searchTerm, setSearchTerm] = useState("");

    const pageSize = 4;

    useEffect(() => {
        const getUsers = async () => {
            const usersFromServer = await fetchUsers();

            setUsers(usersFromServer);
            setPaginetedUsers(_(usersFromServer).slice(0).take(pageSize).value());
        }

        getUsers();

    }, [])

    const fetchUsers = async () => {
        const result = await fetch(environment.API_Url + 'users');
        const data = await result.json();

        return data;
    }

    const fetchUsersFromSearch = async (search) => {
        const result = await fetch(environment.API_Url + 'Users/SearchUsers?searchTerm=' + search);
        const data = await result.json();

        return data;
    }

    const pageCount = users ? Math.ceil(users.length / pageSize) : 0;

    const pages = _.range(1, pageCount + 1);

    const pagination = (pageNumber) => {
        setCurrentPage(pageNumber);
        const startIndex = (pageNumber - 1) * pageSize;
        const paginatedUser = _(users).slice(startIndex).take(pageSize).value();
        setPaginetedUsers(paginatedUser);
    }

    const handleSearch = async () => {
        if (searchTerm !== "") {

            const newUsersList = await fetchUsersFromSearch(searchTerm);
            setSearchedUsers(newUsersList);
        }
        else {
            setSearchedUsers([]);
            setPaginetedUsers(_(paginatedUsers).slice(0).take(pageSize).value());
        }
    }

    const handleLogout = async () => {
        await fetch(environment.API_Url + 'users/logout', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            credentials: 'include',

        });
    }

    return (
        <div>
            <div className={classes.rows}>
                <Row className={classes.rows}>
                    <Col sm="12" md={{ size: 6, offset: 3 }}>
                        <h2>Users</h2>
                    </Col>
                </Row>
            </div>

            <Row className={classes.rows} style={{ marginTop: "20px" }}>
                <Col xs="6" sm="12" md={{ size: 6, offset: 3 }}>
                    <FormGroup>
                        <Input className={classes.input} style={{ float: 'left', width: "400px" }} type="text" onChange={(e) => setSearchTerm(e.target.value)} />
                    </FormGroup>
                    <Button className={classes.btn} color="primary" onClick={handleSearch}>Search
                        <Link to="/posts">
                        </Link></Button>
                    <Link to="/"><Button style={{ marginLeft: "370px" }} className={classes.btn} onClick={handleLogout} color="secondary">Log out</Button></Link>
                </Col>
            </Row>
            {searchedUsers.length !== 0 ?
                <Row className={classes.rows} style={{ marginTop: "20px" }}>
                    <Col sm="12" md={{ size: 6, offset: 3 }}>
                        <Table>
                            <thead>
                                <tr className={classes.theadcolor}>
                                    <th>#</th>
                                    <th>FirstName & LastName</th>
                                    <th>Username</th>
                                    <th>Website</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                {

                                    searchedUsers.map(u => <UsersItem key={u.id} item={u}></UsersItem>)

                                }
                            </tbody>
                        </Table>
                    </Col>
                </Row>

                : <Row className={classes.rows} style={{ marginTop: "20px" }}>
                    <Col sm="12" md={{ size: 6, offset: 3 }}>
                        <Table>
                            <thead>
                                <tr className={classes.theadcolor}>
                                    <th>#</th>
                                    <th>FirstName & LastName</th>
                                    <th>Username</th>
                                    <th>Website</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    paginatedUsers.map(u => <UsersItem key={u.id} item={u}></UsersItem>)
                                }
                            </tbody>
                        </Table>
                    </Col>

                    <Col sm="12" md={{ size: 6, offset: 5 }}>
                        <Pagination size="sm" aria-label="Page navigation example">
                            {
                                pageCount !== 1 ?
                                    pages.map((page) => (
                                        page === currentPage ?

                                            <PaginationItem active>
                                                <PaginationLink onClick={() => pagination(page)}>{page}</PaginationLink>
                                            </PaginationItem> :
                                            <PaginationItem>
                                                <PaginationLink onClick={() => pagination(page)}>{page}</PaginationLink>
                                            </PaginationItem>
                                    )) : null
                            }
                        </Pagination>
                    </Col>
                </Row>}
        </div>
    )
}

export default Users
