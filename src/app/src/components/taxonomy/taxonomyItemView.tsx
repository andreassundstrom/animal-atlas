import { useParams } from "react-router"
import { useApi } from "../../hooks/useApi"
import { ReactNode, useEffect, useState } from "react"
import { GetTaxonomyItemDto } from "../../api/data-contracts"
import Box from "@mui/material/Box"
import { Tab, Tabs, Typography } from "@mui/material"

const CustomTab = ({children, value,index}:{children: ReactNode, index: number, value: number}) => {
    return value === index && <Box>{children}</Box>
}

export const TaxonomyItemView = () => {
    const api = useApi()
    const {taxonomyItemId} = useParams()
    const [taxonomyItem, setTaxonomyItem] = useState<GetTaxonomyItemDto>()
    const [tabPage, setTabPage] = useState(0);
    const handleTabPageChange = (_ : React.SyntheticEvent, newValue: number) => {
        setTabPage(newValue)
    }
    useEffect(() => {
        setTabPage(0)
        if(taxonomyItemId !== undefined){
            api.v1TaxonomyItemsDetail(parseInt(taxonomyItemId))
            .then(res => setTaxonomyItem(res.data))
        }
    },[taxonomyItemId])
    return <Box>
        {taxonomyItem && <>
            <Typography variant="h4">{taxonomyItem.taxonomyItemName}</Typography>
            <Tabs value={tabPage} onChange={handleTabPageChange}>
                <Tab label="View" />
                <Tab label="Edit" />
            </Tabs>
            <CustomTab index={0} value={tabPage}>
                <Typography>View</Typography>
            </CustomTab>
            <CustomTab index={1} value={tabPage}>
                <Typography>Edit</Typography>
            </CustomTab>
        </>
        }
    </Box>
}