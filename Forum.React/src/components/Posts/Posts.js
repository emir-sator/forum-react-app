import React, { useState, useEffect } from 'react'
import {Table, Row, Col, Pagination, PaginationItem, PaginationLink } from 'reactstrap'
import _ from 'lodash'
import { Link } from 'react-router-dom'

import classes from './Posts.module.css'
import PostsItem from './PostsItem';

const Posts = ({ match }) => {

    const [posts, setPosts] = useState([]);
    const [paginatedPosts, setPaginetedPosts] = useState([]);
    const [currentPage, setCurrentPage] = useState(1);
    const pageSize = 5;

    useEffect(() => {
        const getPosts = async () => {
            const postsFromServer = await fetchPosts();

            setPosts(postsFromServer);
            setPaginetedPosts(_(postsFromServer).slice(0).take(pageSize).value());
        }

        getPosts();

    }, [])

    const fetchPosts = async () => {
        const result = await fetch(`https://localhost:44309/api/posts/${match.params.id}`);
        const data = await result.json();

        return data;
    }

    const pageCount = posts ? Math.ceil(posts.length / pageSize) : 0;

    if (pageCount === 1) {
        const posts=fetchPosts();
        return posts;
    }

    const pages = _.range(1, pageCount + 1);

    const pagination = (pageNumber) => {
        setCurrentPage(pageNumber);
        const startIndex = (pageNumber - 1) * pageSize;
        const paginatedPost = _(posts).slice(startIndex).take(pageSize).value();
        setPaginetedPosts(paginatedPost);
    }

    return (
        <div>
            <div className={classes.rows}>
                <Row>
                    <Col className={classes.cols} sm="12" md={{ size: 6, offset: 3 }}>
                        <h2>Posts</h2>
                    </Col>
                </Row>
            </div>

            <div className={classes.rows}>
                <Row  style={{ marginTop: "20px" }}>
                    <Col className={classes.col} sm="12" md={{ size: 6, offset: 3 }}>
                        <Table>
                            <thead>
                                <tr className={classes.theadcolor}>
                                    <th>#</th>
                                    <th>Title</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                {
                                    paginatedPosts.map(u => <PostsItem key={u.id} item={u}></PostsItem>)
                                }
                            </tbody>
                        </Table>
                        <Link to='/users'>Go back</Link>
                    </Col>

                    <Col  sm="12" md={{ size: 6, offset: 5 }}>
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
                </Row>
            </div>
        </div>
    )
}

export default Posts
