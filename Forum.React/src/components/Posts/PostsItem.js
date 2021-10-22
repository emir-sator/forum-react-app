import React, { useState } from 'react'
import { Collapse, Card, CardBody } from 'reactstrap'

import classes from './Posts.module.css'

const PostsItem = ({ item }) => {

    const [isOpen, setIsOpen] = useState(false);

    const toggle = () => setIsOpen(!isOpen);

    return (
            <tr>
                <td>{item.id}</td>
                <td>{item.title}</td>
                <td className={classes.collapseBody} onClick={toggle} >˅

                <Collapse isOpen={isOpen} className={classes.collapseCard}>
                    <Card>
                        <CardBody>
                            {item.body}
                        </CardBody>
                    </Card>
                </Collapse>

                </td>
            </tr>
    )
}

export default PostsItem
