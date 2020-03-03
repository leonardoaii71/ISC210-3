package com.pucmm.player_services.repositories;

import com.pucmm.player_services.models.Player;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.PagingAndSortingRepository;
import org.springframework.data.rest.core.annotation.RepositoryRestResource;

//@RepositoryRestResource(collectionResourceRel = "people", path = "people")
public interface PlayerRepository extends PagingAndSortingRepository<Player, Long> {

}
